module "network_services" {
  source = "modules/kubernetes_cluster"
  env    = var.env
}
