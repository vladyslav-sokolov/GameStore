variable "project_name" {
  type        = string
  default     = "vs-college"
}

variable "region_name" {
  type        = string
  default     = "europe-west3"
}

variable "zone_name" {
  type        = string
  default     = "europe-west3-a"
}

variable "machine_type" {
  type        = string
  default     = "n1-standard-2"
}

variable "name" {
  type        = string
  default     = "spinnaker"
}

variable "node_count" {
  type        = string
  default     = "3"
}

variable "istio_disabled" {
  type        = bool
  default     = false
}