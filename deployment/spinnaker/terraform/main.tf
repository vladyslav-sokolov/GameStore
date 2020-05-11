module "kubernetes_cluster" {
  source         = "./modules/kubernetes_cluster"
  name           = var.name
  location       = var.zone_name
  machine_type   = var.machine_type
  node_count     = var.node_count
  istio_disabled = var.istio_disabled
}

// module "service_account" {
//   source = "./modules/service_account"
//   name = var.name
// }
