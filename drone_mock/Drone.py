import random
from common import Direction, GimbalMoveType, GimbalPosition
from Camera import SimpleCamera
import math
import time
import numpy
import geopy.distance


class Drone:
    # not support delay and stop
    # not support rotate the drone
    def __init__(self, drone_configuration):
        self.alt = 0
        self.lng = drone_configuration['initial_lng']
        self.lat = drone_configuration['initial_lat']
        self.bearing_radians = drone_configuration['initial_bearing_radians']
        self.speed_in_ms = drone_configuration['speed_in_ms']

        self.mistake_in_move = drone_configuration['mistake_in_move']

        self.min_take_off_height = drone_configuration['take_off']['min_height']
        self.max_take_off_height = drone_configuration['take_off']['max_height']

        self.gimbal_delay_in_sec = drone_configuration['gimbal_delay_in_sec']

        self.left_gimbal = Gimbal()
        self.right_gimbal = Gimbal()

        self.camera = SimpleCamera(self, drone_configuration['camera'])

    def take_off(self):
        assert self.alt == 0, "drone height should have been 0"
        self.alt = random.uniform(self.min_take_off_height, self.max_take_off_height)

    def landing(self):
        assert self.alt != 0, "drone height should have been 0"
        self.alt = 0

    def move_drone(self, distance, bearing):
        radius = 6378.1  # Radius of the Earth

        start_lat = self.lat
        start_lng = self.lng

        self.lat = math.asin(math.sin(start_lat) * math.cos(distance / radius) +
                             math.cos(start_lat) * math.sin(distance / radius) * math.cos(bearing))

        self.lng = start_lng + math.atan2(math.sin(bearing) * math.sin(distance / radius) * math.cos(start_lat),
                                          math.cos(distance / radius) - math.sin(start_lat) * math.sin(self.lat))

    def move(self, direction, amount):
        # not support wait now
        error = amount * self.mistake_in_move
        actual_move_amount = random.uniform(amount - error, amount + error)

        if direction == Direction.up:
            self.alt += actual_move_amount
        if direction == Direction.down:
            self.alt -= actual_move_amount
        if direction == Direction.forward:
            self.move_drone(actual_move_amount, self.bearing_radians)
        if direction == Direction.backward:
            self.move_drone(actual_move_amount, self.bearing_radians + math.pi)
        if direction == Direction.right:
            self.move_drone(actual_move_amount, self.bearing_radians + math.pi / 2)
        if direction == Direction.left:
            self.move_drone(actual_move_amount, self.bearing_radians + 3 * math.pi / 2)
        if direction == Direction.left:
            self.bearing_radians += self.bearing_radians * 180 / math.pi

    def move_gimbal(self, gimbal_position, gimbal_movment_type, roll, pitch, yaw):
        time.sleep(self.gimbal_delay_in_sec)
        if gimbal_position == GimbalPosition.left:
            if gimbal_movment_type == GimbalMoveType.absolute:
                self.left_gimbal.move_absolute(roll, pitch, yaw)
            else:
                self.left_gimbal.move_relative(roll, pitch, yaw)
        else:
            if gimbal_movment_type == GimbalMoveType.absolute:
                self.right_gimbal.move_absolute(roll, pitch, yaw)
            else:
                self.right_gimbal.move_relative(roll, pitch, yaw)

    def measure(self, lat_des, lng_des):
        coords_1 = (self.lat, self.lng)
        coords_2 = (lat_des, lng_des)

        return geopy.distance.geodesic(coords_1, coords_2).m

    def go_to_gps(self, lng, lat, alt):
        if alt != self.alt:
            start_alt = self.alt
            for current_alt in numpy.arange(start_alt, alt, 0.5):
                time.sleep(0.5 / self.speed_in_ms)
                self.alt = current_alt

        if lng != self.lng:
            distance_in_meters = self.measure(self.lat, lng)
            start_lng = self.lng

            meter_in_lng_lat = abs(lng - start_lng) / distance_in_meters

            for current_lng in numpy.arange(start_lng, lng, meter_in_lng_lat):
                time.sleep(0.5)
                self.lng = current_lng

        if lat != self.lat:
            distance_in_meters = self.measure(lat, self.lng)
            start_lat = self.lat
            distance_per_sec = abs(lat - start_lat) / distance_in_meters

            for current_lat in numpy.arange(start_lat, lat, distance_per_sec):
                time.sleep(0.5)
                self.lat = current_lat

    def take_photo(self):
        self.camera.take_photo()


class Gimbal:
    def __init__(self):
        self.roll = 0
        self.pitch = 0
        self.yaw = 0

    def move_relative(self, rol, pitch, yaw):
        self.roll += rol
        self.pitch += pitch
        self.yaw += yaw

    def move_absolute(self, rol, pitch, yaw):
        self.roll = rol
        self.pitch = pitch
        self.yaw = yaw
